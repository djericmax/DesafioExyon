import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CiaaereaComponent } from './views/ciaaerea/ciaaerea.component';
import { FooterComponent } from './views/components/footer/footer.component';
import { HeaderComponent } from './views/components/header/header.component';
import { HomeComponent } from './views/components/home/home.component';
import { MenuComponent } from './views/components/menu/menu.component';
import { SidebarComponent } from './views/components/sidebar/sidebar.component';
import { TableComponent } from './views/components/table/table.component';
import { TituloComponent } from './views/components/titulo/titulo.component';
import { TreeComponent } from './views/components/tree/tree.component';
import { UserComponent } from './views/components/user/user.component';
import { PassageiroComponent } from './views/passageiro/passageiro.component';
import { VooComponent } from './views/voo/voo.component';


const routes: Routes = [
  {path: '', redirectTo: 'tree', pathMatch: 'full'},
  {path: '', component: HomeComponent},
  {path: '', component: MenuComponent},
  {path: '', component: SidebarComponent},
  {path: '', component: FooterComponent},
  {path: 'tree', component: TreeComponent},
  {path: '', component: HeaderComponent},
  {path: '', component: TituloComponent},
  {path: '', component: UserComponent},
  {path: '', component: TableComponent},
  {path: 'ciaaerea', component: CiaaereaComponent},
  {path: 'passageiro', component: PassageiroComponent},
  {path: 'voo', component: VooComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
