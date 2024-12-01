export default function TarefaFormulario({titulo, setTitulo, descricao, setDescricao, criaTarefa}) {
  const handleSubmit = (e) => {
    e.preventDefault()

    if (!titulo) 
      return

    criaTarefa(titulo, descricao)
  }

  return (
    <div className="tarefa-formulario">
      <h2>Formulário da tarefa</h2>
      <form onSubmit={handleSubmit}>
        <input type="text" placeholder="Informe o título" 
          onChange={(e) => setTitulo(e.target.value)}
          value={titulo} />
        <input type="text" placeholder="Informe a descrição (opcional)" 
          onChange={(e) => setDescricao(e.target.value)}
          value={!descricao ? "" : descricao}/>
        <button type="submit">Salvar</button>
      </form>
    </div>
  )
}