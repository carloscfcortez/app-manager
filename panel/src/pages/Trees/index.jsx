import React from 'react'
import { Switch, Route } from 'react-router-dom'
import Form from './Form'
import List from './List'

export default function TreesRoutes() {
  return (
    <Switch>
      <Route exact={true} path={'/trees'} component={List} />
      <Route exact={true} path={'/trees/create'} component={Form} />
      <Route path={'/trees/:id'} component={Form} />
    </Switch>
  )
}
