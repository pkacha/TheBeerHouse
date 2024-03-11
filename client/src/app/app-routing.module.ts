import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ArticlesComponent } from './articles/articles.component';
import { NewsletterComponent } from './newsletter/newsletter.component';
import { PollsComponent } from './polls/polls.component';
import { ForumsComponent } from './forums/forums.component';
import { authGuard } from './_guards/auth.guard';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [authGuard],
    children: [
      { path: 'articles', component: ArticlesComponent },
      { path: 'newsletter', component: NewsletterComponent },
      { path: 'polls', component: PollsComponent },
      { path: 'forums', component: ForumsComponent },
    ],
  },
  //{ path: 'errors', component: TestErr },
  { path: 'not-found', component: NotFoundComponent },
  { path: 'server-error', component: ServerErrorComponent },
  { path: '**', component: NotFoundComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
