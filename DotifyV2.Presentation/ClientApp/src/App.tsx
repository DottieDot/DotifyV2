import React, { useEffect } from 'react'
import { createMuiTheme, ThemeProvider } from '@material-ui/core/styles'
import { Provider as StateProvider } from 'react-redux'
import { store, persistor } from './store'
import RootRouter from './RootRouter'
import { PersistGate } from 'redux-persist/integration/react'
import { CssBaseline } from '@material-ui/core'
import { useApiToken } from './hooks'
import { setApiToken } from './api/apiRequest'

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
          <CssBaseline />
          <RegisterApiToken />
          <RootRouter />
        </ThemeProvider>
      </PersistGate>
    </StateProvider>
  )
}
