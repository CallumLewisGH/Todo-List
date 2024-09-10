<template>
    <div class="container2">

    </div>

    <div class="container1">
      <div class="SideBar" id="SideBar">
        <SideBar :inputList="inputList" @updateList="updateList" @updateLoadedList="updateLoadedList" @deleteList="deleteList"/>
      </div>

      <div class="TodoList" id="TodoList">
        <TodoList :usingList="usingList" @updateMainItemList="updateMainItemList" @updateSubItemList="updateSubItemList" @deleteList="deleteList" @deleteMainItem="deleteMainItem"/>
      </div>

    </div>
</template>


<script setup lang ="ts">
  import SideBar from "@/components/SideBar.vue";
  import TodoList from "@/components/TodoList.vue";
  import { onMounted, ref,} from 'vue';
  import {useToast} from 'vue-toastification';
  import { UserDTO, getUserById, getById, TodoListObjectDTO, TodoListObject} from '@/client'

  const toast = useToast();
  const user = ref<UserDTO>({}); 
  const inputList = ref<TodoListObjectDTO[]>([]);
  const usingList = ref<TodoListObjectDTO>({});

onMounted(async () => {
  
  try {
    const response = await getUserById({headers: {id : 0}});
    if (response.data === undefined){
      return;
    }
    const res: UserDTO = {
      id: response.data[0]?.id,
      username: response.data[0]?.username,
      password: response.data[0]?.password
    } 

    user.value = res;
    console.log(user)

  } catch (error) {
    console.log(error)
  }

  try {
    const response = await getById({path: {id: 0}});
    if (response.data === undefined){
      return;
    }
    
    const res = response.data.map(todoList => {
      const res: TodoListObjectDTO = {
        listName: todoList.listName,
        todoListObject: todoList.todoListObject
      } 

      return res;
    })

    inputList.value = res;
    console.log(inputList)

  } catch (error) {
    console.log(error)
  }
});

  const updateList = (newList: TodoListObjectDTO) => {
    inputList.value.push(newList);
    localStorage.setItem('inputList', JSON.stringify(inputList.value));
};

  const deleteList = (index: number) => {
    inputList.value.splice(index, 1)
    usingList.value = {
      listName: "Create or load a list",
      todoListObject: [{mainItem:"Step 1 Select the text box that states Enter List Name...", subItemList: []},
                {mainItem: "Step 2 Enter your desired name", subItemList: []},
                {mainItem:"Step 3 Press Enter", subItemList: []},
                {mainItem:"Step 4 Select the newly created list on the side bar", subItemList: []}
  ]}};

  const updateLoadedList = (list: TodoListObject) => {
    usingList.value.todoListObject?.push(list)
  };

  const updateMainItemList = (mainItemInput: TodoListObject) => {
    if (usingList.value.todoListObject){
      usingList.value.todoListObject.push(mainItemInput)
    } 
  }

  const updateSubItemList = (subItemInput: string, index: number) => {
    if(usingList.value.todoListObject == undefined) return;
    usingList.value.todoListObject[index]?.subItemList?.push(subItemInput)
  }
  const deleteMainItem = (index: number) => {
    usingList.value.todoListObject?.splice(index, 1)
    toast.success('Well Done! You Completed a task!')
  }
</script>