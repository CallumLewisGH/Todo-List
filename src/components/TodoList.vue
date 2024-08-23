<template>
    <div class="todo_list_header">
    <span>{{todo_list_obj.list_name}}</span>
    </div>
        <template v-for="items1,index in todo_list_obj.todo_list">
            <div class="todo_list" @mousedown="isMouseClick = true, actIndex = index">
                <li>{{items1.item_input}}</li>

                <template v-for="items2 in todo_list_obj.todo_list[index].sub_item_list">
                    <li style="padding-left: 2%;">{{items2}}</li>
                </template>

                <template v-if="actIndex === index">
                    <li style="margin-left: 2%;"><input type="text" placeholder="Enter a job todo..." v-model="input_text1" @keyup.enter = "input_text1 = ''" @keydown.enter="handleCreateSubItem(index)"
                    style="size: large;margin: 0%;min-height: 4vh; background-color: #6b6b6b; border-radius: 3vh; border: #494949;  color: azure; min-width: 60%; text-indent: 1%; margin-top: 1%">
                    </li>
                </template>
            </div>
        </template>
        <div class="todo_list_input">
            <li>
                <input type="text" placeholder="Enter a job todo..." v-model="input_text2" @keyup.enter = "input_text2 = ''" @keydown.enter="handleCreateMainItem()"
                style="size: large;margin: 0%;min-height: 4vh; background-color: #6b6b6b; border-radius: 3vh; border: #494949;  color: azure; min-width: 60%; text-indent: 1%;">
            </li>
        </div>

</template>

<script setup>
import { ref, onMounted, } from 'vue';

const input_text1 = ref('')
const input_text2 = ref('')
const isMouseClick = ref(false)
const actIndex = ref(0)

const emit = defineEmits(['updateMainItemList', 'updateSubItemList'])

const props = defineProps({
    todo_list_obj: {
        type: Object,
        required: true,
    }
})

const handleCreateMainItem = () => {
    if (input_text2.value) {
    const newMainItem = {item_input: input_text2.value, sub_item_list: []};
    emit('updateMainItemList', newMainItem);
  }
}

const handleCreateSubItem = (index) => {
    if (input_text1.value) {
    const newSubItem = input_text1.value;
    emit('updateSubItemList', newSubItem, index );

    }
}


</script>