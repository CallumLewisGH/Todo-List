<template>
    <h3 style="text-align: center;">Saved</h3>
    <template v-for="list, index in props.todo_list_list">
        <div @click="handleLoadedList(list)" class="list_link" id="list_link">
            <img src="../assets/TodoListMarker.png" width="17.5%" style="float:left; margin-right: 2%;">
            <span>{{list.getListName()}}</span>
        </div>
    </template>

    <div class="list_link" id="list_link">
        <img src="../assets/TodoListMarker.png" width="17.5%" style="float:left;">
        <input type="text" placeholder="Enter List Name..." v-model="input_text" @keyup.enter = "input_text = ''" @keydown.enter="handleCreateList(input_text)"
        style="size: large; background-color: #494949;min-height: 100%; border-radius: 3vh; border: #494949;  color: azure; max-width: 75%; text-indent: 1%;">
    </div>

</template>

<script setup>
import { ref, onMounted, defineEmits } from 'vue';

const props = defineProps({
    todo_list_list: {
        type: Array,
        required: true,
    }
})

const emit = defineEmits(['updateList', 'updateLoadedList']);

const input_text= ref('')

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

const handleCreateList = () => {
  if (input_text.value.trim()) {
    const newList = new TodoList(input_text.value, []);
    emit('updateList', newList);
  }
};

const handleLoadedList = (loaded_list) => {
    emit('updateLoadedList', loaded_list);
};


</script>