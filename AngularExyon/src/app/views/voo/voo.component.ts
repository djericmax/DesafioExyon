import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Voo } from 'src/app/Models/Voo';
import { VooService } from 'src/app/Services/voo.service';
import { CurrencyPipe } from '@angular/common';
import {
  MAT_MOMENT_DATE_FORMATS,
  MomentDateAdapter,
  MAT_MOMENT_DATE_ADAPTER_OPTIONS,} from '@angular/material-moment-adapter';
import {DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE} from '@angular/material/core';

@Component({
  selector: 'app-voo',
  templateUrl: './voo.component.html',
  styleUrls: ['./voo.component.css'],
  providers: [
    // The locale would typically be provided on the root module of your application. We do it at
    // the component level here, due to limitations of our example generation script.
    {provide: MAT_DATE_LOCALE, useValue: 'pt-BR'},

    // `MomentDateAdapter` and `MAT_MOMENT_DATE_FORMATS` can be automatically provided by importing
    // `MatMomentDateModule` in your applications root module. We provide it at the component level
    // here, due to limitations of our example generation script.
    {
      provide: DateAdapter,
      useClass: MomentDateAdapter,
      deps: [MAT_DATE_LOCALE, MAT_MOMENT_DATE_ADAPTER_OPTIONS]
    },
    {provide: MAT_DATE_FORMATS, useValue: MAT_MOMENT_DATE_FORMATS},
  ],
})
export class VooComponent implements OnInit {

  public modalRef!: BsModalRef;
  public vooForm!: FormGroup;
  titulo = 'Dados de Vôos';
  public vooSelecionado!: Voo;
  public textSimples: string | undefined;
    public modo!: string;

  voos: Voo[] = [];
 
  openModal(lgModal: TemplateRef<any>) {
    this.modalRef = this.modalService.show(lgModal);
  }

  constructor(private currencyPipe: CurrencyPipe,
              private _adapter: DateAdapter<any>,
              private fb: FormBuilder,
              private modalService: BsModalService,
              private vooService: VooService) {
    this.criarForm();
   }

  ngOnInit(): void {
    this.carregaVoos();
    
    }

  carregaVoos() {
      this.vooService.getAll().subscribe(
        (voos: Voo[]) => { 
          this.voos = voos;
         // console.log(voos);
        },
        (erro: any) => {
          console.log(erro);
         }
      );
  }

  criarForm() {
    this.vooForm = this.fb.group({
      id: [''],
      numdoVoo: ['', Validators.required],
      assento: ['', Validators.required],
      dataPartida: ['', Validators.required],
      horapartida: ['', Validators.required],
      valorPassagem: ['', Validators.required],
      ciaAereaId: [0, Validators.required],
      passageiroId: [0, Validators.required]
    }); 
  }

   salvaEditaVoo(voo: Voo) {
    this.vooService.put(voo.id, voo).subscribe(
        (retorno: any) => {
        console.log(retorno);
        this.carregaVoos();
      },
      (erro: any) => { 
        console.log(erro);
      }
    );
  }

  salvaNovoVoo(voo: Voo) {
   this.vooService.post(voo).subscribe(
        (retorno: any) => {
        console.log(retorno);
        this.carregaVoos();
      },
      (erro: any) => { 
        console.log(erro);
      }
    );
  }

  deletar(id: number) {
    this.vooService.delete(id).subscribe(
      (model: any) => {
        console.log(model);
        this.carregaVoos();
      },
      (erro: any) => {
        console.error(erro)
      }
    )
  }

  enviaSubmit(){
    if (this.vooSelecionado.id === 0) {
      this.salvaNovoVoo(this.vooForm?.value);  
    } else {
      this.salvaEditaVoo(this.vooForm?.value);  
    }    
    console.log(this.vooForm?.value);
  }

  vooSelect(voo: Voo) {
    this.vooSelecionado = voo;
    this.vooForm?.patchValue(voo);
  }

  novo() {
    this.vooSelecionado = new Voo();
    this.vooForm?.patchValue(this.vooSelecionado);
  }

  voltar() {
    this.vooSelecionado = null as any;
  } 
}
