import React from 'react';
import TaskItem from './TaskItem';
import { List, Typography } from '@mui/material';

const TaskList = ({ tasks, deleteTask }) => {
  return (
    <List>
      {tasks.length === 0 && <Typography>No tasks available</Typography>}
      {tasks.map((task) => (
        <TaskItem key={task.id} task={task} deleteTask={deleteTask} />
      ))}
    </List>
  );
};

export default TaskList;
