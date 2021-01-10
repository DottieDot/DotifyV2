import { Container } from '@material-ui/core'
import React, { Fragment } from 'react'
import { AppBar } from '../../components'
import Artists from './Artists'

export default () => {
  return (
    <Fragment>
      <AppBar />
      <Container maxWidth="lg">
        <Artists />
      </Container>
    </Fragment>
  )
}
