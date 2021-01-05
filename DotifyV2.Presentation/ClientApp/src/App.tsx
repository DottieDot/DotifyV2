import React, { ReactNode, useEffect, useMemo } from 'react'
import { createMuiTheme, ThemeProvider } from '@material-ui/core/styles'
import { Provider as StateProvider, useDispatch } from 'react-redux'
import { store, persistor } from './store'
import RootRouter from './RootRouter'
import { PersistGate } from 'redux-persist/integration/react'
import { CssBaseline, ThemeOptions, useMediaQuery } from '@material-ui/core'
import { useApiToken } from './hooks'
import { setApiToken } from './api/apiRequest'
import Notifier from './Notifier'
import { SnackbarProvider } from 'notistack'
import { loadUserInfo } from './store/actions/User'
import { useSelectedTheme } from './common'

const lightTheme: ThemeOptions = {
  palette: {
    type: 'light',
    background: {
      paper: '#fff',
      default: '#ededed',
    }
  }
}

const darkTheme: ThemeOptions = {
  palette: {
    type: 'dark',
    primary: {
      main: '#90caf9'
    },
    secondary: {
      main: '#f48fb1'
    }
  }
}

const RegisterApiToken = () => {
  const dispatch = useDispatch()
  const apiToken = useApiToken()

  useEffect(() => {
    setApiToken(apiToken)
    dispatch(loadUserInfo())
  }, [apiToken, dispatch])

  return null
}

const Theme = ({ children }: { children: ReactNode }) => {
  const prefersDarkMode = useMediaQuery('(prefers-color-scheme: dark)')
  const selectedTheme = useSelectedTheme()
  const dark = selectedTheme === 'system' ? prefersDarkMode : selectedTheme === 'dark'
  const theme = useMemo(
    () => createMuiTheme(dark ? darkTheme : lightTheme), 
    [dark]
  )

  return (
    <ThemeProvider theme={theme}>
      {children}
    </ThemeProvider>
  )
}

export default () => {
  return (
    <StateProvider store={store}>
      <PersistGate loading={null} persistor={persistor}>
        <Theme>
          <SnackbarProvider anchorOrigin={{ vertical: 'bottom', horizontal: 'center' }}>
            <CssBaseline />
            <RegisterApiToken />
            <Notifier />
            <RootRouter />
          </SnackbarProvider>
        </Theme>
      </PersistGate>
    </StateProvider>
  )
}
