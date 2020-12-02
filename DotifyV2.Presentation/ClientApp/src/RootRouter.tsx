import React from 'react'
import { BrowserRouter, Route, Switch } from 'react-router-dom'
import { LoginSignupPage } from './pages'

export default () => {
  return (
    <BrowserRouter>
      <Switch>
        <Route path="*">
          <LoginSignupPage />
        </Route>
      </Switch>
    </BrowserRouter>
  )
}
