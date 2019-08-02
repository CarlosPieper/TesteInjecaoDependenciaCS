import { Component, OnInit } from '@angular/core';
import { Cliente } from '../shared/cliente.model';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  cliente: Cliente;

  constructor() { }

  ngOnInit() {
    this.resetForm();
  }
  resetForm(form?: NgForm) {
    if (form != null) {
      form.reset();
      this.cliente = {
        Id: null,
        DataNascimento: null,
        DataRegistro: null,
        Nome: '',
        Email: '',
        Endereco: '',
        Cpf: '',
        Credito: null,
        Senha: '',
      }
    }
  }
}
