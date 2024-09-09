export type todo_list_obj_type = {
    list_name: string;
    todo_list: {
      item_input: string;
      sub_item_list: string[];
    }[];
  }