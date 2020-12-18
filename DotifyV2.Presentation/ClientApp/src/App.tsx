import React, { useEffect } from 'react'
import { createMuiTheme, ThemeProvider } from '@material-ui/core/styles'
import { Provider as StateProvider } from 'react-redux'
import { store, persistor } from './store'
import RootRouter from './RootRouter'
import { PersistGate } from 'redux-persist/integration/react'
import { CssBaseline } from '@material-ui/core'
import { useApiToken } from './hooks'
import { setApiToken } from './api/apiRequest'
import Notifier from './Notifier'
import { SnackbarProvider } from 'notistack'

const theme = createMuiTheme({
  palette: {
    type: 'dark'
  }
})

const RegisterApiToken = () => {
  const apiToken = useApiToken()

  useEffect(() => {
    setApiToken(apiToken)
  }, [apiToken])

  return null
}

export default () => {
  return (
    <StateProvider store={store}>
      <PersistGate loading={null} persistor={persistor}>
        <ThemeProvider theme={theme}>
          <SnackbarProvider anchorOrigin={{ vertical: 'bottom', horizontal: 'center' }}>
            <CssBaseline />
            <RegisterApiToken />
            <Notifier />
            <RootRouter />
          </SnackbarProvider>
        </ThemeProvider>
      </PersistGate>
    </StateProvider>
  )
}