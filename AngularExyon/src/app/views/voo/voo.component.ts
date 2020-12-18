import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Voo } from 'src/app/Models/Voo';
import { VooService } from 'src/app/Services/voo.service';

@Component({
  selector: 'app-voo',
  templateUrl: './voo.component.html',
  styleUrls: ['./voo.component.css']
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

  constructor(private fb: FormBuilder,
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
      ciaAereaId: ['', Validators.required],
      passageiroId: ['', Validators.required]
    }); 
  }

  salvarVoo(vuo: Voo) {

    if (vuo.id === 0) {
      this.modo = 'put';
    } else {
      this.modo = 'post';
    }
    this.vooService[this.modo](vuo).subscribe(
        (retorno: Voo) => {
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
    this.salvarVoo(this.vooForm?.value);
    //console.log(this.vooForm?.value);
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
