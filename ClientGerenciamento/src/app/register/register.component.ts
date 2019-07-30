import { Component, OnInit } from '@angular/core';
import { Cliente } from '../shared/cliente.model';
import { NgForm } from '@angular/forms';
import { format } from 'url';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  cliente: Cliente;
  constructor() { }

  resetForm(form?: NgForm) {
    if (form != null)
      form.reset();
    this.cliente = {
      id: 0,
      dataregistro: null,
      datanascimento: null,
      nome: '',
      email: '',
      endereco: '',
      cpf: '',
      credito: 0,
      senha: '',
    }
  }

  ngOnInit() {
    this.resetForm();
  }

}
