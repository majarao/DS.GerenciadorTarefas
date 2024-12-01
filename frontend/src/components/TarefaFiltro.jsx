export default function TarefaFiltro({filtro, setFiltro}) {
  return (
    <div className="filtro">
      <h2>Filtrar por Status:</h2>
      <div>
        <select value={filtro} onChange={(e) => setFiltro(e.target.value)}>
          <option value="Todos">Todos</option>
          <option value="Pendente">Pendentes</option>
          <option value="Em progresso">Em progresso</option>
          <option value="Concluída">Concluídas</option>
        </select>
      </div>
    </div>
  )
}
