import { Component, OnInit, TemplateRef } from '@angular/core';
import { Validators } from '@angular/forms';
import { FormBuilder, FormGroup } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Passageiro } from 'src/app/Models/Passageiro';
import { PassageiroService } from 'src/app/Services/passageiro.service';


@Component({
  selector: 'app-passageiro',
  templateUrl: './passageiro.component.html',
  styleUrls: ['./passageiro.component.css']
})
export class PassageiroComponent implements OnInit {

  public myModel = ''
  public mask = [/[0-9]/, /[0-9]/, /[0-9]/, '.', /[0-9]/, /[0-9]/, /[0-9]/, '.', /[0-9]/, /[0-9]/, /[0-9]/, '-', /[0-9]/, /[0-9]/]
  public modalRef!: BsModalRef;
  public passageiroForm!: FormGroup;
  titulo = "Dados dos Passageiros"
  public passageiroSelecionado!: Passageiro;
  public textSimples: string | undefined;
  public modo = 'post';

  public passageiros: Passageiro[] = [];
 
  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  constructor(private fb: FormBuilder,
              private modalService: BsModalService,
              private passageiroService: PassageiroService) {
    this.criarForm();
   }

  ngOnInit(): void {
    this.carregaPassageiros();
  }

  carregaPassageiros() {
      this.passageiroService.getAll().subscribe(
        (passageiros: Passageiro[]) => { 
          this.passageiros = passageiros;
          //console.log(passageiros);
        },
        (erro: any) => {
          console.log(erro);
         }
      );
  }

  criarForm() {
    this.passageiroForm = this.fb.group({
      id: [''],
      cpf: ['', Validators.required],
      nome: ['', Validators.required],
      sobrenome: ['', Validators.required] 
    }); 
  }

   salvaEditaPassageiro(pass: Passageiro) {
    this.passageiroService.put(pass.id, pass).subscribe(
        (model: any) => {
        console.log(model);
        this.carregaPassageiros();
      },
      (erro: any) => { 
        console.log(erro);
      }
    );
  }

  salvaNovoPassageiro(pass: Passageiro) {
   this.passageiroService.post(pass).subscribe(
        (model: any) => {
        console.log(model);
        this.carregaPassageiros();
      },
      (erro: any) => { 
        console.log(erro);
      }
    );
  }

  deletar(id: number) {
    this.passageiroService.delete(id).subscribe(
      (model: any) => {
        console.log(model);
        this.carregaPassageiros();
      },
      (erro: any) => {
        console.error(erro)
      }
    )
  }

  enviaSubmit(){
    if (this.passageiroSelecionado.id === 0) {
      this.salvaNovoPassageiro(this.passageiroForm?.value);  
    } else {
      this.salvaEditaPassageiro(this.passageiroForm?.value);  
    }    
    console.log(this.passageiroForm?.value);
  }

  passageiroSelect(passageiro: Passageiro) {
    this.passageiroSelecionado = passageiro;
    this.passageiroForm?.patchValue(passageiro);
  }

  novo() {
    this.passageiroSelecionado = new Passageiro();
    this.passageiroForm?.patchValue(this.passageiroSelecionado);
  }

  voltar() {
    this.passageiroSelecionado = null as any;
  }
}
