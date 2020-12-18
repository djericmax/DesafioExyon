import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Ciaaerea } from 'src/app/Models/Ciaaerea';
import { Passageiro } from 'src/app/Models/Passageiro';
import { Voo } from 'src/app/Models/Voo';
import { CiaaereaService } from 'src/app/Services/ciaaerea.service';
import { PassageiroService } from 'src/app/Services/passageiro.service';
import { VooService } from 'src/app/Services/voo.service';


@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']  
})
export class TableComponent implements OnInit {

  public modalRef!: BsModalRef;
  public tableForm!: FormGroup;
  titulo = 'Dados de Vôos';
  public tableSelecionado: Voo | undefined;
  public textSimples: string | undefined;

  voos: Voo[] = [];
  vuo: Voo = new Voo;
  passageiros: Passageiro[] = [];
  ciaaereas: Ciaaerea[] = [];
  ciaaereaId: number = 4;
 
  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  constructor(private fb: FormBuilder,
              private modalService: BsModalService,
              private passageiroService: PassageiroService,
              private ciaaereaService: CiaaereaService,
              private vooService: VooService) {
    this.criarForm();
   }

  ngOnInit(): void {
    this.carregaVoos();
    this.carregaCiaaereas();
    this.carregaPassageiros();
    this.carregaVooByciaAereaId();
  }

  carregaPassageiros() {
      this.passageiroService.getAll().subscribe(
        (passageiros: Passageiro[]) => { 
          this.passageiros = passageiros;
        //  console.log(passageiros);
        },
        (erro: any) => {
          console.log(erro);
         }
      );
  }

  carregaCiaaereas() {
    this.ciaaereaService.getAll().subscribe(
      (ciaaerea: Ciaaerea[]) => {
        this.ciaaereas = ciaaerea;
      //  console.log(ciaaerea);
      },
      (erro: any) => {
        console.log(erro);
      }
    );
  }

  carregaVoos() {
      this.vooService.getAll().subscribe(
        (voos: Voo[]) => { 
          this.voos = voos;
          console.log(voos);
        },
        (erro: any) => {
          console.log(erro);
         }
      );
  }

  carregaVooByciaAereaId() {
      this.vooService.getByciaAereaId(this.ciaaereaId).subscribe(
        (vuo: Voo) => { 
          this.vuo = vuo;
          console.log(vuo);
        },
        (erro: any) => {
          console.log(erro);
         }
      );
  }

  criarForm() {
    this.tableForm = this.fb.group({
      id: [''],
      cpf: ['', Validators.required],
      nome: ['', Validators.required],
      sobrenome: ['', Validators.required],
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
    this.vooService.puttable(vuo.id, vuo).subscribe(
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
    this.salvarVoo(this.tableForm?.value);
    //console.log(this.vooForm?.value);
  }

  tableSelect(table: Voo) {
    this.tableSelecionado = table;
    this.tableForm?.patchValue(table);
  }

  voltar() {
    this.tableSelecionado = null as any;
  }
}
