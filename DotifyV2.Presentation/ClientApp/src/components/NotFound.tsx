import { Container, Typography } from '@material-ui/core'
import React, { Fragment } from 'react'
import AppBar from './AppBar'

interface Props {
  text: string
}

export default ({ text }: Props) => {
  return (
    <Fragment>
      <AppBar />
      <Container maxWidth="lg">
        <Typography variant="h5" component="h2">404 Not Found</Typography>
        <Typography variant="h6" component="h3">{text}</Typography>
      </Container>
    </Fragment>
  )
}
