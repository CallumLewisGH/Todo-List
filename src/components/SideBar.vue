<template>
    <h3 style="text-align: center;">Saved</h3>
    <template v-for="list in inputList">
        <div @click="handleLoadedList(list)" class="list_link" id="list_link">
            <img src="../assets/TodoListMarker.png" width="25vh%" style="float:left; margin-right: 2%;">
            <img src="../assets/Cross.png" width="17.5vh" style=" float: right; margin-top: 2%; margin-right: 3%;" @click="handleDeleteList(list.listId?? 0)">
            <span>{{list.listName}}</span>
        </div>
    </template>

    <div class="list_link" id="list_link">
        <img src="../assets/TodoListMarker.png" width="25vh%" style="float:left;">
        <input type="text" placeholder="Enter List Name..." v-model="input_text" @keyup.enter = "input_text = ''" @keydown.enter="handleCreateList(input_text, userId )"
        style="size: large; background-color: #494949;min-height: 100%; border-radius: 3vh; border: #494949;  color: azure; max-width: 75%; text-indent: 1%;">
    </div>

</template>

<script setup lang="ts">
import { ref, } from 'vue';
import { type TodoListDTO, type TodoListObjectDTO} from '@/client'


defineProps<{
  inputList: TodoListObjectDTO[]; 
  userId: number;
}>()

const emit = defineEmits(['updateList', 'updateLoadedList', 'deleteList' ]);

const input_text= ref<string>('')

const handleCreateList = (input_text: string, inputUserId: number) => {
  if (input_text) {
    const newList: TodoListDTO = {
      listName: input_text, 
      userId: inputUserId,
};
    emit('updateList', newList);
  }
};

const handleLoadedList = (list: TodoListObjectDTO) => {
    emit('updateLoadedList', list);
};

const handleDeleteList = ( index: number) => {
    emit('deleteList', index)
}


</script>