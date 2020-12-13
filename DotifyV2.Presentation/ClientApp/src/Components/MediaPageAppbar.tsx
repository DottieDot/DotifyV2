import { AppBar, Container, makeStyles, Toolbar, Typography } from '@material-ui/core'
import { Skeleton } from '@material-ui/lab'
import React, { ReactElement } from 'react'
import AddPropsWhenScrolled from './AddPropsWhenScrolled'

const useStyles = makeStyles(theme => ({
  appBar: {
    transition: 'box-shadow 300ms cubic-bezier(0.4, 0, 0.2, 1) 0ms, background 300ms cubic-bezier(0.4, 0, 0.2, 1) 0ms',
    background: theme.palette.background.paper,
    color: theme.palette.text.primary,
  },
  restingAppbar: {
    background: theme.palette.background.default,
  },
  spacing: {
    width: 12,
  },
  toolbar: {
    paddingRight: 0,
    paddingLeft: 0,
  }
}))

interface Props {
  avatar: ReactElement
  title: string | null | undefined
}

export default ({ title, avatar }: Props) => {
  const classes = useStyles()

  return (
    <AddPropsWhenScrolled props={{ elevation: 4, className: classes.appBar }}>
      <AppBar elevation={0} className={`${classes.restingAppbar} ${classes.appBar}`} position="sticky">
        <Container fixed>
          <Toolbar className={classes.toolbar}>
            {avatar}
            <div className={classes.spacing} />
            {title ? (
              <Typography variant="h6" component="h1">
                {title}
              </Typography>
            ) : (
                <Skeleton animation="wave">
                  <Typography variant="h6" component="h1">
                    Loading...
              </Typography>
                </Skeleton>
              )}
          </Toolbar>
        </Container>
      </AppBar>
    </AddPropsWhenScrolled>
  )
}
