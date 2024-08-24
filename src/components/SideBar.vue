<template>
    <h3 style="text-align: center;">Saved</h3>
    <template v-for="list, index in props.todo_list_list">
        <div @click="handleLoadedList(list , index)" class="list_link" id="list_link">
            <img src="../assets/TodoListMarker.png" width="17.5%" style="float:left; margin-right: 2%;">
            <img src="../assets/Cross.png" width="10%" style=" float: right; margin-top: 3%; margin-right: 3%;" @click="handleDeleteList(index)">
            <p style="margin-top: 3%;">{{list.list_name}}</p>
        </div>
    </template>

    <div class="list_link" id="list_link">
        <img src="../assets/TodoListMarker.png" width="17.5%" style="float:left;">
        <input type="text" placeholder="Enter List Name..." v-model="input_text" @keyup.enter = "input_text = ''" @keydown.enter="handleCreateList(input_text)"
        style="size: large; background-color: #494949;min-height: 100%; border-radius: 3vh; border: #494949;  color: azure; max-width: 75%; text-indent: 1%;">
    </div>

</template>

<script setup>
import { ref, onMounted, } from 'vue';

const props = defineProps({
    todo_list_list: {
        type: Array,
        required: true,
    }
})

const emit = defineEmits(['updateList', 'updateLoadedList', 'deleteList' ]);

const input_text= ref('')

const handleCreateList = () => {
  if (input_text.value) {
    const newList = {list_name: input_text.value, todo_list: []};
    emit('updateList', newList);
  }
};

const handleLoadedList = (index) => {
    emit('updateLoadedList', index);
};

const handleDeleteList = (list , index) => {
    emit('deleteList', list, index)
}


</script>