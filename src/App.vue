<template>
  <div class="masterContainer">
    <div class="container2">
      <div class ="header" id="Header">
        <Header></Header>

      </div>
    </div>

    <div class="container1">
      <div class="SideBar" id="SideBar">
        <SideBar :todo_list_list="todo_list_list" @updateList="updateList" @updateLoadedList="updateLoadedList"/>
      </div>

      <div class="TodoList" id="TodoList">
        <TodoList :todo_list_obj="todo_list_obj"/>
      </div>


    </div>
  </div>
</template>




<script setup>
  import SideBar from "./components/SideBar.vue";
  import Header from "./components/Header.vue"
  import TodoList from "./components/TodoList.vue";
  import { ref, onMounted } from 'vue';

  const todo_list_list = ref([])
  const todo_list_obj = ref({
    list_name: "Create or load a list",
    todo_list: ["Step 1 Select the text box that states Enter List Name...",
    "Step 2 Enter your desired name",
    "Step 3 Press Enter",
    "Step 4 Select the newly created list on the side bar"
]})

  const updateList = (newList) => {
    todo_list_list.value.push(newList);
};

  const updateLoadedList = (inputList) => {
    todo_list.value = inputList
  }

</script>