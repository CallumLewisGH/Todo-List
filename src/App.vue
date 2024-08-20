<template>
  <div class="masterContainer">
    <div class="container1">
      <div class="Logo" id="Logo">
        <logo></logo>
      </div>

      <div class="SideBar" id="SideBar">
        <SideBar></SideBar>
      </div>

    </div>

    <div class="container2">
      <div class ="header" id="Header">
        <Header></Header>

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
  import logo from "./components/logo.vue";
</script>