import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Conta } from 'src/app/models/Conta';
import { ContaPagarService } from './conta-pagar.service';

@Component({
  selector: 'app-contas-pagar',
  templateUrl: './contas-pagar.component.html',
  styleUrls: ['./contas-pagar.component.css']
})
export class ContasPagarComponent implements OnInit {

  public contaForm: FormGroup;
  public contaSelecionado: Conta;
  public contas: Conta[];
  public conta: Conta;
  public modo = this.contaService.Adicionar;
  public searchText:any;
  public mensagem: string;

  page = 1;
  count = 0;
  tableSize = 10;

  constructor(private fb: FormBuilder, private contaService: ContaPagarService) {
    this.criarForm();
  }

  ngOnInit(): void {
    this.carregarContas();
  }

  carregarContas() {
    this.contaService.BuscarTodasContas(1).subscribe(
      (contas: Conta[]) => {
        this.contas = contas;
      },
      (erro: any) => {
        console.error(erro);
      }
    );
  }

  criarForm() {
    this.contaForm = this.fb.group({
      id: [0],
      descricao: ['', Validators.required],
      valor: [0, Validators.required],
      status: [false, Validators.required],
      tipo: [0, Validators.required]
    });
  }

  contaSelect(conta: Conta) {
    this.contaSelecionado = conta;
    this.contaForm.patchValue(conta);
  }

  cadastrarConta() {
    this.contaSelecionado = new Conta;
    this.contaSelecionado.tipo = 1;
    this.contaForm.patchValue(this.contaSelecionado);
  }

  salvarConta(conta: Conta) {
    if (conta.id == 0) {
      this.contaService.Adicionar(conta).subscribe(
        conta => {
          this.carregarContas();
          this.mensagem = "Conta cadastrada";
        },
        (erro: any) => {
          console.log(erro);
        }
      );
    }
    else {
      this.contaService.Atualizar(conta).subscribe(
        conta => {
          this.carregarContas();
          this.mensagem = "Conta atualizada";
        },
        (erro: any) => {
          console.log(erro);
        }
      );
    }
  }

  contaSubmit() {
    this.salvarConta(this.contaForm.value);
  }

  voltar() {
    this.contaSelecionado = null;
  }

  onTableDataChange(event: any) {
    this.page = event;
    this.carregarContas();
  }

  onTableSizeChange(event: any): void {
    this.tableSize = event.target.value;
    this.page = 1;
    this.carregarContas();
  }
}