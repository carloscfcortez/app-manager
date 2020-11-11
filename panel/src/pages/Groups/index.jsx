import React from 'react'
import { Switch, Route } from 'react-router-dom'
import Form from './Form'
import List from './List'

export default function GroupsRoutes() {
  return (
    <Switch>
      <Route exact={true} path={'/groups'} component={List} />
      <Route exact={true} path={'/groups/create'} component={Form} />
      <Route path={'/groups/:id'} component={Form} />
    </Switch>
  )
}
