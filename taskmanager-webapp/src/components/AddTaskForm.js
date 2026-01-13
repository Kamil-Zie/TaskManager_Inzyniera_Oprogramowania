import React, { useState } from 'react';
import { TextField, Button } from '@mui/material';

const AddTaskForm = ({ addTask }) => {
  const [taskName, setTaskName] = useState('');
  const [taskDateStart, setTaskDateStart] = useState('');
  const [taskDateEnd, setTaskDateEnd] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault();
    if (!taskName) return;
    addTask({ taskName, taskDateStart, taskDateEnd });
    setTaskName('');
    setTaskDateStart('');
    setTaskDateEnd('');
  };

  return (
    <form onSubmit={handleSubmit}>
      <TextField
        label="Task Name"
        value={taskName}
        onChange={(e) => setTaskName(e.target.value)}
      />
      <TextField
        label="Start Date"
        type="date"
        value={taskDateStart}
        onChange={(e) => setTaskDateStart(e.target.value)}
        InputLabelProps={{
          shrink: true,
        }}
      />
      <TextField
        label="End Date"
        type="date"
        value={taskDateEnd}
        onChange={(e) => setTaskDateEnd(e.target.value)}
        InputLabelProps={{
          shrink: true,
        }}
      />
      <Button type="submit" variant="contained">Add Task</Button>
    </form>
  );
};

export default AddTaskForm;
