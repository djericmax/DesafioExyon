import { Component, OnInit, TemplateRef } from '@angular/core';
import { Validators } from '@angular/forms';
import { FormBuilder, FormGroup } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Ciaaerea } from 'src/app/Models/Ciaaerea';
import { CiaaereaService } from 'src/app/Services/ciaaerea.service';
//import { } from '@angular/material-moment-adapter';

@Component({
  selector: 'app-ciaaerea',
  templateUrl: './ciaaerea.component.html',
  styleUrls: ['./ciaaerea.component.css']
})
export class CiaaereaComponent implements OnInit {

  public modalRef!: BsModalRef;
  public ciaaereaForm!: FormGroup;
  titulo = 'Companhias Aéreas';
  public ciaaereaSelecionado!: Ciaaerea;
  public textSimples: string | undefined;
  public modo!: string;

  public ciaaereas: Ciaaerea[] = [];
 
  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  constructor(private fb: FormBuilder,
              private modalService: BsModalService,
              private ciaaereaService: CiaaereaService) {
    this.criarForm();
   }

  ngOnInit(): void {
    this.carregaCiaaereas();
  }

  carregaCiaaereas() {
      this.ciaaereaService.getAll().subscribe(
        (ciaaereas: Ciaaerea[]) => { 
          this.ciaaereas = ciaaereas;
          //console.log(ciaaereas);
        },
        (erro: any) => {
          console.log(erro);
         }
      );
  }

  criarForm() {
    this.ciaaereaForm = this.fb.group({
      id: [''],
      companhiaAerea: ['', Validators.required],
      aviao: ['', Validators.required],
      qtdeAssentos: ['', Validators.required]
    }); 
  }

  salvaEditaCiaaerea(cia: Ciaaerea) {
    this.ciaaereaService.put(cia.id, cia).subscribe(
        (retorno: Ciaaerea) => {
        console.log(retorno);
        this.carregaCiaaereas();
      },
      (erro: any) => { 
        console.log(erro);
      }
    );
  }

  salvaNovoCiaaerea(cia: Ciaaerea) {
   this.ciaaereaService.post(cia).subscribe(
        (retorno: Ciaaerea) => {
        console.log(retorno);
        this.carregaCiaaereas();
      },
      (erro: any) => { 
        console.log(erro);
      }
    );
  }

  deletar(id: number) {
    this.ciaaereaService.delete(id).subscribe(
      (model: any) => {
        console.log(model);
        this.carregaCiaaereas();
      },
      (erro: any) => {
        console.error(erro)
      }
    )
  }

  enviaSubmit(){
    if (this.ciaaereaSelecionado.id === 0) {
      this.salvaNovoCiaaerea(this.ciaaereaForm?.value);  
    } else {
      this.salvaEditaCiaaerea(this.ciaaereaForm?.value);  
    }    
    console.log(this.ciaaereaForm?.value);
  }

  ciaaereaSelect(ciaaerea: Ciaaerea) {
    this.ciaaereaSelecionado = ciaaerea;
    this.ciaaereaForm?.patchValue(ciaaerea);
  }

  novo() {
    this.ciaaereaSelecionado = new Ciaaerea();
    this.ciaaereaForm?.patchValue(this.ciaaereaSelecionado);
  }

  voltar() {
    this.ciaaereaSelecionado = null as any;
  }
}
