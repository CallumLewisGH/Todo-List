<template>
    <div class="container2">

    </div>

    <div class="container1">
      <div class="SideBar" id="SideBar">
        <SideBar :inputList="inputList" :userId="userId" @updateList="updateList" @updateLoadedList="updateLoadedList" @deleteList="deleteList"/>
      </div>

      <div class="TodoList" id="TodoList">
        <TodoList :usingList="usingList" @updateMainItemList="updateMainItemList" @updateSubItemList="updateSubItemList" @deleteList="deleteList" @deleteMainItem="deleteMainItem"/>
      </div>

    </div>
</template>


<script setup lang ="ts">
  import SideBar from "@/components/SideBar.vue";
  import TodoList from "@/components/TodoList.vue";
  import { onMounted, ref} from 'vue';
  import {useToast} from 'vue-toastification';
  import { postUserTodoListTask, deleteUserTodoListTaskById, TodoListObjectDTO, deleteUserTodoListById, postUserTodoList, CreateTodoListRequest, CreateTaskRequest, postUserTodoListTaskSubtask, CreateSubTaskRequest} from '@/client'
  import { readDataById } from "@/client/getData";
  import { useUserStore } from "@/store";
  import router from "@/router";

  const usingIndex = ref<number>();
  const userStore = useUserStore();
  const userId = ref<number>()
  const toast = useToast();
  const inputList = ref<TodoListObjectDTO[]>([]);
  const usingList = ref<TodoListObjectDTO>({});
  const defaultList = ref<TodoListObjectDTO>({listName: "Create a Todo-List", 
                                               todoListObject: 
                                               [{mainItem: "Click a On the Input box that states Enter List Name..."}, 
                                                {mainItem: "Enter the list name you want"}, 
                                                {mainItem: "Press Enter"}]})
  userId.value = userStore.userID

onMounted(async () => {
  userId.value = userStore.userID
  userId.value = JSON.parse(localStorage.getItem('UserId') || '')

  if(userId.value != undefined){
  inputList.value = await readDataById(userId.value)?? []
  }
  
  else {
    router.push("/login")
  }
  usingList.value = inputList.value[usingList.value.listId?? 0]?? defaultList.value
});

  const updateList = async(newList: CreateTodoListRequest) => {
    await postUserTodoList({body: newList })
    inputList.value = await readDataById(userId.value?? 0)?? [defaultList.value]
    usingList.value = inputList.value.find(x => x.listName == newList.listName) ?? defaultList.value


};

  const deleteList = async(inputId: number) => {
    await deleteUserTodoListById({ path: {id: inputId} })
    inputList.value = await readDataById(userId.value?? 0)?? [defaultList.value]
    usingList.value = inputList.value[0]?? defaultList.value
    toast.success('Well Done! You Completed a List!')
};
  

  const updateLoadedList = (list: TodoListObjectDTO) => {
    usingList.value = list
    usingIndex.value = inputList.value.findIndex(x => x == list)
  };

  const updateMainItemList = async(mainItemInput: CreateTaskRequest ) => {
    await postUserTodoListTask({body: mainItemInput})
    inputList.value = await readDataById(userId.value?? 0)?? [defaultList.value]
    usingList.value = inputList.value[usingIndex.value?? 0]?? defaultList.value
    
  }

  const updateSubItemList = async(inputSubTask: CreateSubTaskRequest) => {
    await postUserTodoListTaskSubtask({body: inputSubTask})
    inputList.value = await readDataById(userId.value?? 0)?? [defaultList.value]
    usingList.value = inputList.value[usingIndex.value?? 0]?? defaultList.value
    
  }

  const deleteMainItem = async(inputId: number) => {
    await deleteUserTodoListTaskById({path: {id: inputId}})
    inputList.value = await readDataById(userId.value?? 0)?? [defaultList.value]
    usingList.value = inputList.value[usingIndex.value?? 0]?? defaultList.value
    
    toast.success('Well Done! You Completed a task!')
  }
</script>