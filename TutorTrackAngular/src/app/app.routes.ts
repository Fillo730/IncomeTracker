//Angular
import { Routes } from '@angular/router';

//Components
import { CurrentMonthPage } from './pages/dashboard/current-month.page';
import { LayoutComponent } from './components/layout/layout';
import { AddEntryPage } from './pages/add-entry/add-entry.page';

export const routes: Routes = [
    { 
        path: '', 
        component: LayoutComponent,
        children: [
            { path: 'current-month', component: CurrentMonthPage },
            { path: 'add-entry', component: AddEntryPage},
            { path: '', redirectTo: 'current-month', pathMatch: 'full' }
        ]
    },
];