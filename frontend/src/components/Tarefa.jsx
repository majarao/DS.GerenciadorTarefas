import { useState, useEffect } from 'react'
import api from '../services/api'
import TarefaLista from './TarefaLista'
import TarefaFormulario from './TarefaFormulario'

export default function Tarefa() {
  const [id, setId] = useState("")
  const [titulo, setTitulo] = useState("")
  const [descricao, setDescricao] = useState("")
  const [tarefas, setTarefas] = useState([])

  useEffect(() => {
    api.get('api/tarefas').then(
      response=> 
        {
          setTarefas(response.data);
        })
  }, [null])

  async function criaTarefa(titulo, descricao) {
    const tarefa = {
      titulo,
      descricao
    }

    try
    {
      if (!id)
        await api.post('api/tarefas', tarefa);
      else
        await api.put(`api/tarefas/${id}`, tarefa);

      api.get('api/tarefas').then(
        response=> 
          {
            setTarefas(response.data);
          })
    }
    catch(error)
    {
      alert('Erro ao gravar tarefa ' + error);
    }

    setId("")
    setTitulo("")
    setDescricao("")    
  }

  async function editaTarefa(id, titulo, descricao) {
    setId(id)
    setTitulo(titulo)
    setDescricao(descricao)
  }  

  async function iniciaTarefa(id) {
    try
    {
      await api.put(`api/tarefas/${id}/iniciar`);

      const tarefasExistentes = [...tarefas]
      tarefasExistentes.map((tarefa) => tarefa.id === id ? tarefa.status = "Em progresso" : tarefa)
  
      setTarefas(tarefasExistentes)      
    }
    catch(error)
    {
      alert('Erro ao iniciar tarefa ' + error);
    }
  }

  async function concluiTarefa(id) {
    try
    {
      await api.put(`api/tarefas/${id}/concluir`);

      const tarefasExistentes = [...tarefas]
      tarefasExistentes.map((tarefa) => tarefa.id === id ? tarefa.status = "Concluída" : tarefa)
  
      setTarefas(tarefasExistentes)      
    }
    catch(error)
    {
      alert('Erro ao concluir tarefa ' + error);
    }
  }  

  async function excluiTarefa(id) {
    try
    {
      await api.delete(`api/tarefas/${id}`);

      const tarefasExistentes = [...tarefas]
      const tarefasRestantes = tarefasExistentes.filter((tarefa) => tarefa.id !== id ? tarefa : null)
  
      setTarefas(tarefasRestantes)   
    }
    catch(error)
    {
      alert('Erro ao excluir tarefa ' + error);
    }
  }  

  return (
    <div className='app'>
      <TarefaLista 
        tarefas={tarefas} 
        criaTarefa={criaTarefa}
        iniciaTarefa={iniciaTarefa} 
        concluiTarefa={concluiTarefa}
        editaTarefa={editaTarefa}
        excluiTarefa={excluiTarefa} />
      <TarefaFormulario titulo={titulo} setTitulo={setTitulo} descricao={descricao} setDescricao={setDescricao} criaTarefa={criaTarefa} />
    </div>
  )
}
