import React from 'react'
import { BrowserRouter, Route, Switch } from 'react-router-dom'
import { LoginSignupPage } from './pages'
import { useIsAuthenticated } from './hooks'
import { useDispatch } from 'react-redux'
import { logout as logoutAction } from './store/actions/Auth'

const UnAuthenticatedRoutes = () => {
  return (
    <Route path="*">
      <LoginSignupPage />
    </Route>
  )
}

const AuthenticatedRoutes = () => {
  const dispatch = useDispatch()

  const logout = () => {
    dispatch(logoutAction())
  }

  return (
    <button onClick={logout}>Logout</button>
  )
}

export default () => {
  const isAuthenticated = useIsAuthenticated()

  return (
    <BrowserRouter>
      <Switch>
        {isAuthenticated 
          ? <AuthenticatedRoutes /> 
          : <UnAuthenticatedRoutes />}
      </Switch>
    </BrowserRouter>
  )
}
