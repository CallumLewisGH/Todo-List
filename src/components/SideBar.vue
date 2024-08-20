<template>
    <template v-for="list, index in todo_list_list">
        <div @click="loaded_list = list.value" class="list_link" id="list_link">
            <img src="../assets/TodoListMarker.png" width="35vh" style="float:left; margin-top: 1vh;">
            <p style="margin-top: 2vh;">{{list.getListName()}}</p>
        </div>
    </template>

    <div class="list_link" id="list_link">
        <img src="../assets/TodoListMarker.png" width="35vh" style="float:left; margin-top: 1vh;">
        <input type="text" placeholder="Enter List Name..." v-model="input_text2" @keyup.enter = "input_text2 = ''" @keydown.enter="createList(input_text2)"
        style="margin-inline: 1vh; margin-top: 0.66vh; size: large; background-color: #3f3f3f; height: 6vh; border-radius: 3vh; border: #3f3f3f;  color: azure;">
    </div>

</template>

<script setup>

import { ref, computed, onMounted } from 'vue';
const input_text1 = ref('')
const input_text2 = ref('')
const todo_list_list = ref([]);
const loaded_list = ref(null);

class TodoList {
    constructor(list_name, todo_list,){
        this.list_name = list_name;
        this.todo_list = todo_list;
    }

    addTodoMainItem = () => {
        const item = new mainItem("MainItem INPUT", [])
        this.todo_list.push(item)
    }

    getListName = () => {
        return this.list_name;
    }

    getTodoList = () => {
        return this.todo_list;
    }

}

const createList = (input) => {
    if (input.trim()) {
        todo_list_list.value.push(new TodoList(input, ["Look at me I'm todo ITEM 1"]));
    }
}

const editList = (input, index) => {
    if (input.trim()) {
        todo_list_list.value.splice(index, 1, new TodoList(input, []));
    }
}

</script>