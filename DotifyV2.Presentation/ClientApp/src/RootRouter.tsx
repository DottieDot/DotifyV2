import React, { Fragment } from 'react'
import { BrowserRouter, Route, Switch, useHistory, useRouteMatch } from 'react-router-dom'
import { ArtistPage, LoginSignupPage } from './pages'
import { useIsAuthenticated } from './hooks'
import { useDispatch } from 'react-redux'
import { logout as logoutAction } from './store/actions/Auth'
import AlbumPage from './pages/AlbumPage'
import { AnimatedSwitch, spring } from 'react-router-transition'
import { makeStyles } from '@material-ui/core'

const mapStyles = (styles: any) => {
  return {
    opacity: styles.opacity,
    transform: `scale(${styles.scale})`,
  }
}

const bounce = (val: any) => {
  return spring(val, {
    stiffness: 800,
    damping: 60,
  })
}

const bounceTransition = {
  atEnter: {
    opacity: 0,
    scale: 1.2,
  },
  atLeave: {
    opacity: bounce(0),
    scale: bounce(0.8),
  },
  atActive: {
    opacity: bounce(1),
    scale: bounce(1),
  },
}


const useStyles = makeStyles({
  switchWrapper: {
    position: 'relative',
    '& > div': {
      position: 'absolute',
      width: '100%',
    }
  }
})

const UnAuthenticatedRoutes = () => {
  return (
    <Switch>
      <Route path="*">
        <LoginSignupPage />
      </Route>
    </Switch>
  )
}

const AuthenticatedRoutes = () => {
  const classes = useStyles()
  const dispatch = useDispatch()
  const shouldLogout = useRouteMatch('/logout')
  const history = useHistory()

  if (shouldLogout) {
    dispatch(logoutAction())
    history.replace('/')
  }

  return (
    <AnimatedSwitch
      atEnter={bounceTransition.atEnter}
      atLeave={bounceTransition.atLeave}
      atActive={bounceTransition.atActive}
      className={classes.switchWrapper}
      mapStyles={mapStyles}
    >
      <Route path="/artists/:artist">
        <ArtistPage />
      </Route>
      <Route path="/albums/:album">
        <AlbumPage />
      </Route>
    </AnimatedSwitch>
  )
}

export default () => {
  const isAuthenticated = useIsAuthenticated()

  return (
    <BrowserRouter>
      {isAuthenticated
        ? <AuthenticatedRoutes />
        : <UnAuthenticatedRoutes />}
    </BrowserRouter>
  )
}
