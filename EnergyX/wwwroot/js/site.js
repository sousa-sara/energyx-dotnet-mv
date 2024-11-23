function showModal(action, relatorio = {}) {
    const modalTitle = document.getElementById("modalRelatorioLabel");
    const form = document.getElementById("formRelatorio");
    const btnFormRelatorio = document.getElementById("btn-form-relatorio");

    const actionFormCreate = (display) => {
        document.querySelectorAll('.form-create').forEach((inputDiv) => {
            inputDiv.style.display = display;
            const input = inputDiv.querySelector("textarea, select, input");
            if (input) {
                if (display === "none") {
                    input.removeAttribute("required");
                } else {
                    input.setAttribute("required", "required");
                }
            }
        });
    };
    

    if (action === "add") {
        modalTitle.textContent = "Adicionar Relatório";
        btnFormRelatorio.textContent = "Salvar relatório";
        form.reset();
        document.getElementById("RelatorioTurnoId").value = 0;
        actionFormCreate("block");
        
        
    } else if (action === "edit") {
        modalTitle.textContent = "Editar Relatório";
        btnFormRelatorio.textContent = "Atualizar relatório";
        actionFormCreate("none");

        // Preenche os campos do formulário com os dados do relatório
        document.getElementById("RelatorioTurnoId").value = relatorio.RelatorioTurnoId;
        document.getElementById("ResumoAtividades").value = relatorio.ResumoAtividades;
        document.getElementById("Observacoes").value = relatorio.Observacoes;
        document.getElementById("OperadorId").value = relatorio.OperadorId;
        document.getElementById("ReatorId").value = relatorio.ReatorId;
    }
}

function showModalDelete(RelatorioTurnoId) {
    document.getElementById("RelatorioTurnoIdDelete").value = RelatorioTurnoId;
    console.log('ID do Relatório para exclusão:', RelatorioTurnoId);
}


