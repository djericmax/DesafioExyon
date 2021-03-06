import { BrowserModule } from '@angular/platform-browser';
import { LOCALE_ID, NgModule } from '@angular/core';

import { HomeComponent } from './views/components/home/home.component';
import { MenuComponent } from './views/components/menu/menu.component';
import { SidebarComponent } from './views/components/sidebar/sidebar.component';
import { TreeComponent } from './views/components/tree/tree.component';
import { FooterComponent } from './views/components/footer/footer.component';
import { HeaderComponent } from './views/components/header/header.component';
import { TituloComponent } from './views/components/titulo/titulo.component';
import { UserComponent } from './views/components/user/user.component';
import { TableComponent } from './views/components/table/table.component';
import { CiaaereaComponent } from './views/ciaaerea/ciaaerea.component';
import { PassageiroComponent } from './views/passageiro/passageiro.component';
import { VooComponent } from './views/voo/voo.component';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatListModule} from '@angular/material/list';
import {MatDividerModule} from '@angular/material/divider';
import {MatMenuModule} from '@angular/material/menu';
import {MatTooltipModule} from '@angular/material/tooltip';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { CurrencyMaskModule } from 'ng2-currency-mask';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ModalModule } from 'ngx-bootstrap/modal';
import { HttpClientModule } from '@angular/common/http';
import { CPFPipe } from './views/cpf.pipe';
import { MatTreeModule } from '@angular/material/tree';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatInputModule } from '@angular/material/input';
import { MatBadgeModule } from '@angular/material/badge';
import { TextMaskModule } from 'angular2-text-mask';
import { NgxMaterialTimepickerModule } from 'ngx-material-timepicker';
import { registerLocaleData } from '@angular/common';
import { CurrencyPipe } from '@angular/common';
import localePt from '@angular/common/locales/pt';


registerLocaleData(localePt)


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    MenuComponent,
    SidebarComponent,
    TreeComponent,
    FooterComponent,
    HeaderComponent,
    TituloComponent,
    UserComponent,
    TableComponent,
    CiaaereaComponent,
    PassageiroComponent,
    VooComponent,
    CPFPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatSidenavModule,
    MatListModule,
    MatDividerModule,
    MatMenuModule,
    MatTreeModule,
    MatTooltipModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    CurrencyMaskModule,
    FormsModule,
    ReactiveFormsModule,
    ModalModule.forRoot(),
    HttpClientModule,
    MatDatepickerModule,
    MatInputModule,
    MatBadgeModule,
    TextMaskModule,
    NgxMaterialTimepickerModule,
  ],
  providers: [{provide: LOCALE_ID, useValue: 'pt-BR'}, CurrencyPipe],
  bootstrap: [AppComponent]
})
export class AppModule { }