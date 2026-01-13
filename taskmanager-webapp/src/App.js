import {
  Box,
  Typography
} from "@mui/material";
import { useEffect, useState } from "react";
import AddTaskForm from './components/AddTaskForm';
import TaskList from './components/TaskList';


function App() {
    const [tasks, setTasks] = useState([]);

    const handleFetch = async () => {
      const response = await fetch("http://localhost:5130/api/tasks");
      if(!response.ok)
        throw new Error("Failed to fetch tasks");
      const data = await response.json();
      setTasks(data);
    }

    const addTask = async (task) => {
      const response = await fetch("http://localhost:5130/api/tasks", {
        method: "POST",
        headers: {
          "Content-Type": "application/json"
        },
        body: JSON.stringify(task)
      });
      if(!response.ok)
        throw new Error("Failed to add task");
      await handleFetch();
    }

    const deleteTask = async (id) => {
      const response = await fetch(`http://localhost:5130/api/tasks/${id}`, {
        method: "DELETE"
      });
      if(!response.ok)
        throw new Error("Failed to delete task");
      await handleFetch();
    }

    useEffect(() => {
      handleFetch();
    }, []);

  return (
    <Box>
      <Typography variant="h4">Task Manager</Typography>
      <AddTaskForm addTask={addTask} />
      <TaskList tasks={tasks} deleteTask={deleteTask} />
    </Box>
  );
}

export default App;
