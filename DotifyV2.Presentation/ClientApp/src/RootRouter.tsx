import React, { Fragment } from 'react'
import { BrowserRouter, Route, Switch, useHistory, useRouteMatch } from 'react-router-dom'
import { ArtistPage, LoginSignupPage } from './pages'
import { useIsAuthenticated } from './hooks'
import { useDispatch } from 'react-redux'
import { logout as logoutAction } from './store/actions/Auth'
import AlbumPage from './pages/AlbumPage'

const UnAuthenticatedRoutes = () => {
  return (
    <Route path="*">
      <LoginSignupPage />
    </Route>
  )
}

const AuthenticatedRoutes = () => {
  const dispatch = useDispatch()
  const shouldLogout = useRouteMatch('/logout')
  const history = useHistory()

  if (shouldLogout) {
    dispatch(logoutAction())
    history.replace('/')
  }

  return (
    <Fragment>
      <Route path="/artists/:artist">
        <ArtistPage />
      </Route>
      <Route path="/albums/:album">
        <AlbumPage />
      </Route>
    </Fragment>
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
