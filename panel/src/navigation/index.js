import React from "react";
import { createBrowserHistory } from "history";
import { Router, Route, Switch, Redirect } from "react-router-dom";
import Dashboard from "../pages/Dashboard";
import Groups from "../pages/Groups";
import GroupEdit from "../pages/Groups/Form";

const hist = createBrowserHistory();

export function Navigation() {
  return (
    <Router history={hist}>
      <Switch>
        <Route exact={true} path="/" component={Dashboard}></Route>
        <Route path="/dashboard" component={Dashboard}></Route>
        <Route path="/groups" exact={true} component={Groups}></Route>
        <Route path="/groups/edit/:id" component={GroupEdit}></Route>
        <Route path="/groups/edit" component={GroupEdit}></Route>

        {/* <Redirect to={"/dashboard"} /> */}
      </Switch>
    </Router>
  );
}