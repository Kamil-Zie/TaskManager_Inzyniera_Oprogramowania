import React from 'react';
import { ListItem, ListItemText, Stack, Button } from '@mui/material';

const TaskItem = ({ task, deleteTask }) => {
  return (
    <ListItem>
      <Stack>
        <ListItemText primary={task.taskName} />
        <ListItemText secondary={task.taskDateStart} />
        <ListItemText secondary={task.taskDateEnd} />
        <Button variant="outlined" color="error" onClick={() => deleteTask(task.id)}>
          Delete
        </Button>
      </Stack>
    </ListItem>
  );
};

export default TaskItem;
