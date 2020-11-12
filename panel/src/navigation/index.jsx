import React from 'react'
import { createBrowserHistory } from 'history'
import { BrowserRouter, Route, Switch, Redirect } from 'react-router-dom'
import Dashboard from '../pages/Dashboard'
import GroupsRouptes from '../pages/Groups'
import SpeciesRoutes from '../pages/Species'
import TreesRoutes from '../pages/Trees'

const hist = createBrowserHistory()

export function Navigation() {
  return (
    <BrowserRouter history={hist}>
      <Switch>
        <Route exact path="/" component={Dashboard}></Route>
        <Route path="/dashboard" component={Dashboard}></Route>
        <Route path="/groups" component={GroupsRouptes}></Route>
        <Route path="/species" component={SpeciesRoutes}></Route>
        <Route path="/trees" component={TreesRoutes}></Route>
        <Redirect to={'/dashboard'}></Redirect>
      </Switch>
    </BrowserRouter>
  )
}
