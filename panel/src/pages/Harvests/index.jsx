import React from 'react'
import { Switch, Route } from 'react-router-dom'
import Form from './Form'
import List from './List'

export default function TreesRoutes() {
  return (
    <Switch>
      <Route exact={true} path={'/harvests'} component={List} />
      <Route exact={true} path={'/harvests/create'} component={Form} />
      <Route path={'/harvests/:id'} component={Form} />
    </Switch>
  )
}
