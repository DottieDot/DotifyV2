import React from 'react'
import { createMuiTheme, ThemeProvider } from '@material-ui/core/styles'
import { Provider as StateProvider } from 'react-redux'
import { store, persistor } from './store'
import RootRouter from './RootRouter'
import { PersistGate } from 'redux-persist/integration/react'
import { CssBaseline } from '@material-ui/core'

const theme = createMuiTheme({

})

export default () => {
  return (
    <StateProvider store={store}>
      <PersistGate loading={null} persistor={persistor}>
        <ThemeProvider theme={theme}>
          <CssBaseline />
          <RootRouter />
        </ThemeProvider>
      </PersistGate>
    </StateProvider>
  )
}
