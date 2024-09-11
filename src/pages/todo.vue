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

  const toast = useToast();
  const user = ref<UserDTO>({});
  const inputList = ref<TodoListObjectDTO[]>([]);
  const usingList = ref<TodoListObjectDTO>({});

onMounted(async () => {

  
  const response = await getById({path: {id: 0}});
  if (response.data === undefined){
    return;
  }
  
  const ListRes = response.data.map(todoList => {
    const ListRes: TodoListObjectDTO = {
      listName: todoList.listName,
      listId: todoList.listId,
      todoListObject: todoList.todoListObject
    } 
    return ListRes;
  })
  inputList.value = ListRes;

});

usingList.value = {
      listName: "Create or load a list",
      todoListObject: [{mainItem:"Step 1 Select the text box that states Enter List Name...", subItemList: []},
                {mainItem: "Step 2 Enter your desired name", subItemList: []},
                {mainItem:"Step 3 Press Enter", subItemList: []},
                {mainItem:"Step 4 Select the newly created list on the side bar", subItemList: []}
  ]};

  const updateList = (newList: TodoListDTO) => {
    postUserTodoList({body: newList })

};

  const deleteList = (inputId: number) => {
    deleteUserTodoListById({ path: {id: inputId} })

    usingList.value = {
      listName: "Create or load a list",
      todoListObject: [{mainItem:"Step 1 Select the text box that states Enter List Name...", subItemList: []},
                {mainItem: "Step 2 Enter your desired name", subItemList: []},
                {mainItem:"Step 3 Press Enter", subItemList: []},
                {mainItem:"Step 4 Select the newly created list on the side bar", subItemList: []}],
      listId: 9999999999 // Set to 0
  }};
  

  const updateLoadedList = (list: TodoListObjectDTO) => {
    usingList.value = list
  };

  const updateMainItemList = (mainItemInput: TaskDTO ) => {
    postUserTodoListTask({body: mainItemInput})
  }

  const updateSubItemList = (inputSubTask: SubTaskDTO) => {
    postUserTodoListTaskSubtask({body: inputSubTask})
  }

  const deleteMainItem = (inputId: number) => {
    deleteUserTodoListTaskById({path: {id: inputId}})
    toast.success('Well Done! You Completed a task!')
  }
</script>