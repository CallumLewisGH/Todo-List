<template>
    <div class="container2">

    </div>

    <div class="container1">
      <div class="SideBar" id="SideBar">
        <SideBar :inputList="inputList" @updateList="updateList" @updateLoadedList="updateLoadedList" @deleteList="deleteList"/>
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
  import { postUserTodoListTask, deleteUserTodoListTaskById, postUser, UserDTO, getById, TodoListObjectDTO, TodoListObject, deleteUserTodoListById, putUserTodoListById, postUserTodoList, CreateTodoListRequestSchema, deleteUserById, TodoListDTO, TaskDTO, postUserTodoListTaskSubtask, SubTaskDTO} from '@/client'
  import { readDataById } from "@/client/getData";

  const toast = useToast();
  const user = ref<UserDTO>({});
  const inputList = ref<TodoListObjectDTO[]>([]);
  const usingList = ref<TodoListObjectDTO>({});

onMounted(async () => {inputList.value = await readDataById(0)});

usingList.value = {
      listName: "Create or load a list",
      todoListObject: [{mainItem:"Step 1 Select the text box that states Enter List Name...", subItemList: []},
                {mainItem: "Step 2 Enter your desired name", subItemList: []},
                {mainItem:"Step 3 Press Enter", subItemList: []},
                {mainItem:"Step 4 Select the newly created list on the side bar", subItemList: []}],
      listId: 9999999999 // Set to 0
  };

  const updateList = async(newList: TodoListDTO) => {
    await postUserTodoList({body: newList })
    inputList.value = await readDataById(0)
    usingList.value = inputList.value[usingList.value.listId]
    
    

};

  const deleteList = async(inputId: number) => {
    await deleteUserTodoListById({ path: {id: inputId} })

    usingList.value = {
      listName: "Create or load a list",
      todoListObject: [{mainItem:"Step 1 Select the text box that states Enter List Name...", subItemList: []},
                {mainItem: "Step 2 Enter your desired name", subItemList: []},
                {mainItem:"Step 3 Press Enter", subItemList: []},
                {mainItem:"Step 4 Select the newly created list on the side bar", subItemList: []}],
      listId: 9999999999 // Set to 0
  }
  inputList.value = await readDataById(0)
  usingList.value = inputList.value[usingList.value.listId]
  
  toast.success('Well Done! You Completed a List!')
};
  

  const updateLoadedList = (list: TodoListObjectDTO) => {
    usingList.value = list
  };

  const updateMainItemList = async(mainItemInput: TaskDTO ) => {
    await postUserTodoListTask({body: mainItemInput})
    inputList.value = await readDataById(0)
    usingList.value = inputList.value[usingList.value.listId]
    
  }

  const updateSubItemList = async(inputSubTask: SubTaskDTO) => {
    await postUserTodoListTaskSubtask({body: inputSubTask})
    inputList.value = await readDataById(0)
    usingList.value = inputList.value[usingList.value.listId]
    
  }

  const deleteMainItem = async(inputId: number) => {
    await deleteUserTodoListTaskById({path: {id: inputId}})
    inputList.value = await readDataById(0)
    usingList.value = inputList.value[usingList.value.listId]
    
    toast.success('Well Done! You Completed a task!')
  }
</script>