<template>
    <div class="container2">

    </div>

    <div class="container1">
      <div class="SideBar" id="SideBar">
        <SideBar :todo_list_list="todo_list_list" @updateList="updateList" @updateLoadedList="updateLoadedList" @deleteList="deleteList"/>
      </div>

      <div class="TodoList" id="TodoList">
        <TodoList :todo_list_obj="todo_list_obj" @updateMainItemList="updateMainItemList" @updateSubItemList="updateSubItemList" @deleteList="deleteList" @deleteMainItem="deleteMainItem"/>
      </div>

    </div>
</template>


<script setup lang ="ts">
  import SideBar from "@/components/SideBar.vue";
  import TodoList from "@/components/TodoList.vue";
  import { onMounted, ref,} from 'vue';
  import {useToast} from 'vue-toastification';
  import { UserDTO, getUserById, getUserTodoList, TodoListDTO, getUserTodoListTask, TaskDTO, getUserTodoListTaskSubtask, SubTaskDTO} from '@/client'
  import type { todo_list_obj_type } from "@/types/todo_list_obj";
  import type { todo_list_list_type } from "@/types/todo_list_list";
  import type { main_item_type } from "@/types/main_item";

  const toast = useToast();

  const todo_list_list = ref<todo_list_list_type>([]); 

  const todo_list_obj = ref<todo_list_obj_type>({

  list_name: "Create or load a list",
  todo_list: [{item_input:"Step 1 Select the text box that states Enter List Name...", sub_item_list: []},
              {item_input: "Step 2 Enter your desired name", sub_item_list: []},
              {item_input:"Step 3 Press Enter", sub_item_list: []},
              {item_input:"Step 4 Select the newly created list on the side bar", sub_item_list: []}
  ]});

  let user = ref<UserDTO>({}); 
  let userTodoLists = ref<TodoListDTO[]>([]);
  let userTodoListTasks = ref<TaskDTO[]>([]);
  let userTodoListSubTasks = ref<SubTaskDTO[]>([]);

onMounted(async () => {
  
  try {
    const response = await getUserById({headers: {id : 0}});
    user = response.data?? {};
    console.log(user)

  } catch (error) {
    console.log(error)
  }
  
  try {
    const response = await getUserTodoList({headers: {userId : 0}})
    userTodoLists = response.data?? [];
    console.log(userTodoLists)

  } catch (error) {
    console.log(error)
  }

  try {
    const response = await getUserTodoListTask({headers: {todoListId : 0}})
    userTodoListTasks = response.data?? [];
    console.log(userTodoListTasks)

  } catch (error) {
    console.log(error)
  }
  
  try {
    const response = await getUserTodoListTaskSubtask({headers: {taskId : 0}})
    userTodoListSubTasks = response.data?? [];
    console.log(userTodoListSubTasks)

  } catch (error) {
    console.log(error)
  }

  
  

  
  const local_list = localStorage.getItem('todo_list_list');

  if (local_list) {
    todo_list_list.value = JSON.parse(local_list);
  }
});

  const updateList = (newList: todo_list_obj_type) => {
    todo_list_list.value.push(newList);
    localStorage.setItem('todo_list_list', JSON.stringify(todo_list_list.value));
};

  const deleteList = (index: number) => {
    todo_list_list.value.splice(index, 1)
    localStorage.setItem('todo_list_list', JSON.stringify(todo_list_list.value));
    todo_list_obj.value = {

      list_name: "Create or load a list",
      todo_list: [{item_input:"Step 1 Select the text box that states Enter List Name...", sub_item_list: []},
      {item_input: "Step 2 Enter your desired name", sub_item_list: []},
      {item_input:"Step 3 Press Enter", sub_item_list: []},
      {item_input:"Step 4 Select the newly created list on the side bar", sub_item_list: []}
      ]}
    toast.success('Well Done! You completed the todo list!')
  }

  const updateLoadedList = (list: todo_list_obj_type) => {
    todo_list_obj.value = list
    localStorage.setItem('todo_list_list', JSON.stringify(todo_list_list.value));
  }
  
  const updateMainItemList = (mainItemInput: main_item_type) => {
    todo_list_obj.value.todo_list.push(mainItemInput)
    localStorage.setItem('todo_list_list', JSON.stringify(todo_list_list.value));
  }

  const updateSubItemList = (subItemInput: string, index: number) => {
    console.log(todo_list_obj.value.todo_list[0])
    todo_list_obj.value.todo_list[index]?.sub_item_list.push(subItemInput ?? "");
    localStorage.setItem('todo_list_list', JSON.stringify(todo_list_list.value));
  }
  const deleteMainItem = (index: number) => {
    todo_list_obj.value.todo_list.splice(index, 1)
    localStorage.setItem('todo_list_list', JSON.stringify(todo_list_list.value));
    toast.success('Well Done! You Completed a task!')
  }
</script>