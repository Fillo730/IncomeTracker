//Angular
import { Routes } from '@angular/router';

//Components
import { CurrentMonthPage } from './pages/dashboard/current-month.page';
import { LayoutComponent } from './components/layout/layout';
import { AddEntryPage } from './pages/add-entry/add-entry.page';
import { CurrentYearPage } from './pages/current-year/current-year.page';
import { StudentsPage } from './pages/students/students.page';
import { LoginPage } from './pages/login/login.page';

//Guards
import { authGuard } from './guards/auth.guard';

export const routes: Routes = [
    { path: 'login', component: LoginPage },
    {
        path: '',
        component: LayoutComponent,
        canActivate: [authGuard],
        children: [
            { path: 'current-month', component: CurrentMonthPage },
            { path: 'current-year', component: CurrentYearPage },
            { path: 'add-entry', component: AddEntryPage},
            { path: 'students', component: StudentsPage},
            { path: '', redirectTo: 'current-month', pathMatch: 'full' }
        ]
    },
];