<template>
  <div class="masterContainer">
    <div class="container2">

      <div></div>
      <div class ="header" id="Header">
        <Header></Header>

      </div>
    </div>

    <div class="container1">
      <div class="SideBar" id="SideBar">
        <SideBar :todo_list_list="todo_list_list" @updateList="updateList" @updateLoadedList="updateLoadedList" @deleteList="deleteList"/>
      </div>

      <div class="TodoList" id="TodoList">
        <TodoList :todo_list_obj="todo_list_obj" @updateMainItemList="updateMainItemList" @updateSubItemList="updateSubItemList" @deleteList="deleteList" @deleteMainItem="deleteMainItem"/>
      </div>

    </div>
  </div>
</template>


<script setup lang ="ts">
  import SideBar from "./components/SideBar.vue";
  import Header from "./components/Header.vue"
  import TodoList from "./components/TodoList.vue";
  import { onMounted, ref,} from 'vue';
  import {useToast} from 'vue-toastification';
  import { getTodos,} from '@/client'

  const toast = useToast();
  const todo_list_list = ref([])
  const todo_list_obj = ref({

    list_name: "Create or load a list",
    todo_list: [{item_input:"Step 1 Select the text box that states Enter List Name...", sub_item_list: []},
    {item_input: "Step 2 Enter your desired name", sub_item_list: []},
    {item_input:"Step 3 Press Enter", sub_item_list: []},
    {item_input:"Step 4 Select the newly created list on the side bar", sub_item_list: []}
    ]})



onMounted(async () => {
  try {
    const todos = await getTodos()
    console.log(todos)
  } catch (error) {
    console.log(error)
  }
  
  const local_list = localStorage.getItem('todo_list_list');

  if (local_list) {
    todo_list_list.value = JSON.parse(local_list);
  }
});

  const updateList = (newList) => {
    todo_list_list.value.push(newList);
    localStorage.setItem('todo_list_list', JSON.stringify(todo_list_list.value));
};

  const deleteList = (index) => {
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

  const updateLoadedList = (inputList, index) => {
    if (todo_list_list.value.includes(inputList)) {
    todo_list_obj.value = inputList
    localStorage.setItem('todo_list_list', JSON.stringify(todo_list_list.value));
    }

    else {
      todo_list_obj.value = {
        list_name: "Create or load a list",
        todo_list: [{item_input:"Step 1 Select the text box that states Enter List Name...", sub_item_list: []},
        {item_input: "Step 2 Enter your desired name", sub_item_list: []},
        {item_input:"Step 3 Press Enter", sub_item_list: []},
        {item_input:"Step 4 Select the newly created list on the side bar", sub_item_list: []}
        ]}
            }
  }

  const updateMainItemList = (mainItemInput) => {
    todo_list_obj.value.todo_list.push(mainItemInput)
    localStorage.setItem('todo_list_list', JSON.stringify(todo_list_list.value));
  }

  const updateSubItemList = (subItemInput, index) => {
    todo_list_obj.value.todo_list[index].sub_item_list.push(subItemInput)
    localStorage.setItem('todo_list_list', JSON.stringify(todo_list_list.value));
  }
  const deleteMainItem = (index) => {
    todo_list_obj.value.todo_list.splice(index, 1)
    localStorage.setItem('todo_list_list', JSON.stringify(todo_list_list.value));
    toast.success('Well Done! You Completed a task!')
  }
</script>