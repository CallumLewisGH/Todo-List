<template>
  <div class="masterContainer">
    <div class="container2">
      <div class ="header" id="Header">
        <Header></Header>

      </div>
    </div>

    <div class="container1">
      <div class="SideBar" id="SideBar">
        <SideBar></SideBar>
      </div>
      <div class="TodoList" id="TodoList">
        <TodoList></TodoList>
      </div>


    </div>
  </div>
</template>




<script setup>
  import SideBar from "./components/SideBar.vue";
  import Header from "./components/Header.vue"
  import TodoList from "./components/TodoList.vue";
  import { ref, computed, onMounted } from 'vue';
</script>