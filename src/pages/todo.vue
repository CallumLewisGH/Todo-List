<template>
    <div class="container2">

    </div>

    <div class="container1">
      <div class="SideBar" id="SideBar">
        <SideBar :inputList="inputList" :userId.value="userId" @updateList="updateList" @updateLoadedList="updateLoadedList" @deleteList="deleteList"/>
      </div>

      <div class="TodoList" id="TodoList">
        <TodoList :usingList="usingList" @updateMainItemList="updateMainItemList" @updateSubItemList="updateSubItemList" @deleteList="deleteList" @deleteMainItem="deleteMainItem"/>
      </div>

    </div>
</template>


<script setup lang ="ts">
  import SideBar from "@/components/SideBar.vue";
  import TodoList from "@/components/TodoList.vue";
  import { onMounted, ref,} from 'vue';
  import {useToast} from 'vue-toastification';
  import { postUserTodoListTask, deleteUserTodoListTaskById, UserDTO, TodoListObjectDTO, deleteUserTodoListById, postUserTodoList, TodoListDTO, TaskDTO, postUserTodoListTaskSubtask, SubTaskDTO} from '@/client'
  import { readDataById } from "@/client/getData";
  import { readUserDataById } from "@/client/getUserData";

  const toast = useToast();
  const userId = ref<number>(0);
  const user = ref<UserDTO>({});
  const inputList = ref<TodoListObjectDTO[]>([]);
  const usingList = ref<TodoListObjectDTO>({});

onMounted(async () => {
  inputList.value = await readDataById(userId.value)?? []
  user.value = await readUserDataById(userId.value)?? {}
});


  const updateList = async(newList: TodoListDTO) => {
    await postUserTodoList({body: newList })
    inputList.value = await readDataById(userId.value)?? []


};

  const deleteList = async(inputId: number) => {
    await deleteUserTodoListById({ path: {id: inputId} })
    inputList.value = await readDataById(userId.value)?? []

  
  toast.success('Well Done! You Completed a List!')
};
  

  const updateLoadedList = (list: TodoListObjectDTO) => {
    usingList.value = list
  };

  const updateMainItemList = async(mainItemInput: TaskDTO ) => {
    await postUserTodoListTask({body: mainItemInput})
    inputList.value = await readDataById(userId.value)?? []

    usingList.value = inputList.value[usingList.value.listId?? 0]?? {}
    
  }

  const updateSubItemList = async(inputSubTask: SubTaskDTO) => {
    await postUserTodoListTaskSubtask({body: inputSubTask})
    inputList.value = await readDataById(userId.value)?? []

    usingList.value = inputList.value[usingList.value.listId?? 0]?? {}
    
  }

  const deleteMainItem = async(inputId: number) => {
    await deleteUserTodoListTaskById({path: {id: inputId}})
    inputList.value = await readDataById(userId.value)?? []

    usingList.value = inputList.value[usingList.value.listId?? 0]?? {}
    
    toast.success('Well Done! You Completed a task!')
  }
</script>