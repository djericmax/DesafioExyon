import {FlatTreeControl} from '@angular/cdk/tree';
import {Component, OnInit} from '@angular/core';
import { FormBuilder } from '@angular/forms';
import {MatTreeFlatDataSource, MatTreeFlattener} from '@angular/material/tree';
import { BsModalService } from 'ngx-bootstrap/modal';
import { Ciaaerea } from 'src/app/Models/Ciaaerea';
import { Voo } from 'src/app/Models/Voo';
import { CiaaereaService } from 'src/app/Services/ciaaerea.service';
import { VooService } from 'src/app/Services/voo.service';
import {NestedTreeControl} from '@angular/cdk/tree';
import {MatTreeNestedDataSource} from '@angular/material/tree';

/**
 * Food data with nested structure.
 * Each node has a name and an optional list of children.
 */
interface FoodNode {
  name: string;
  children?: FoodNode[];
}

const TREE_DATA: FoodNode[] = [
  {
    name: 'Companhia: LaTam', children: [
      {name: 'Vôo: 05', children: [
        {name: ''}]},
    ]
  },
  {
    name: 'Companhia: Azul', children: [
      {name: 'Vôo: 03', children: [
        {name: ''}]},
      ]}
  ];
    

/** Flat node with expandable and level information */
interface FlatNode {
  expandable: boolean;
  name: string;
  level: number;
}

/**
 * @title Tree with flat nodes
 */
@Component({
  selector: 'app-tree',
  templateUrl: './tree.component.html',
  styleUrls: ['./tree.component.css'],
})
export class TreeComponent {
  
  titulo = 'Descrição de Vôos';
  voos: Voo[] = [];

  private _transformer = (node: FoodNode, level: number) => {
    return {
      expandable: !!node.children && node.children.length > 0,
      name: node.name,
      level: level,
    };
  }
  
  treeControl = new FlatTreeControl<FlatNode>(
      node => node.level, node => node.expandable);

  treeFlattener = new MatTreeFlattener(
      this._transformer, node => node.level, node => node.expandable, node => node.children);

  dataSource = new MatTreeFlatDataSource(this.treeControl, this.treeFlattener);

  constructor(private fb: FormBuilder,
              private modalService: BsModalService,
              private vooService: VooService) {
    this.dataSource.data = TREE_DATA;
  }

   ngOnInit(): void {
    this.carregaVoos();
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

  hasChild = (_: number, node: FlatNode) => node.expandable;
}
