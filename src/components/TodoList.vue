<template>
    <div class="todo_list_header">
    <span>{{usingList.listName}}</span>
    <img src="../assets/Cross.png" width="17.5vh" style=" float:right; margin-top: 1%; margin-right: 1%;" @click="handleDeleteList(index)">
    </div>
        <template v-for="main_item,index in usingList.todoListObject">
            <div class="todo_list" @mousedown="isMouseClick = true, clickIndex = index">
                <li>{{main_item.mainItem}}</li>
                <img src="../assets/Cross.png" width="17.5vh" style=" float:right; margin-top: -2%; margin-right: 5%;" @click="handleMainItem(index)">

                <template v-for="sub_item in main_item.subItemList">
                    <li style=" margin-left: 2%; margin-top: 1%;">{{sub_item}}</li>
                </template>

                <template v-if="clickIndex === index">
                    <li style="margin-left: 2%;"><input type="text" placeholder="Enter a job todo..." v-model="input_text1" @keyup.enter = "input_text1 = ''" @keydown.enter="handleCreateSubItem(index, input_text1)"
                    style="size: large;margin: 0%;min-height: 4vh; background-color: #6b6b6b; border-radius: 3vh; border: #494949;  color: azure; min-width: 60%; text-indent: 1%; margin-top: 1%">
                    </li>
                </template>
            </div>
        </template>
        <div class="todo_list_input">
            <li>
                <input type="text" placeholder="Enter a job todo..." v-model="input_text2" @keyup.enter = "input_text2 = ''" @keydown.enter="handleCreateMainItem(input_text2)"
                style="size: large;margin: 0%;min-height: 4vh; background-color: #6b6b6b; border-radius: 3vh; border: #494949;  color: azure; min-width: 60%; text-indent: 1%;">
            </li>
        </div>

</template>

<script setup lang="ts">
import { ref, } from 'vue';
import type { TodoListObjectDTO } from '@/client/';

const input_text1 = ref<string>('')
const input_text2 = ref<string>('')
const isMouseClick = ref<boolean>(false)
const clickIndex = ref<number | 0>(0); 
const index = ref<number | 0>(0); 

const emit = defineEmits(['updateMainItemList', 'updateSubItemList', 'deleteList', 'deleteMainItem'])

defineProps<{
  usingList: TodoListObjectDTO;
}>();

const handleCreateMainItem = (input_text2: string) => {
    if (input_text2) {
    const newMainItem = {mainItem: input_text2, subItemList: []};
    emit('updateMainItemList', newMainItem);
  }
}

const handleCreateSubItem = (index: number, input_text1: string) => {
    if (input_text1) {
    emit('updateSubItemList', input_text1, index );

    }
}
const handleDeleteList = (index: number) => {
    emit('deleteList', index)
}

const handleMainItem = (index: number) => {
    emit('deleteMainItem', index)
}



</script>