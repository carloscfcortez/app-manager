import React from 'react'
import { Switch, Route } from 'react-router-dom'
import Form from './Form'
import List from './List'

export default function SpeciesRoutes() {
  return (
    <Switch>
      <Route exact={true} path={'/species'} component={List} />
      <Route exact={true} path={'/species/create'} component={Form} />
      <Route path={'/species/:id'} component={Form} />
    </Switch>
  )
}
