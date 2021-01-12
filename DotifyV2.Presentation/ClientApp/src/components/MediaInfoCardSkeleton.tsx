import { Card, CardContent, CardMedia, Grid, makeStyles, Typography, Button, useTheme, useMediaQuery, Portal } from '@material-ui/core'
import React, { MutableRefObject } from 'react'
import AddPropsWhenScrolled from './AddPropsWhenScrolled'
import MediaCoverSkeleton from './MediaCoverSkeleton'
import { Skeleton } from '@material-ui/lab'

const useStyles = makeStyles(theme => ({
  card: {
    position: 'sticky',
    top: 75,
    [theme.breakpoints.down('sm')]: {
      display: 'flex',
      flexDirection: 'row',
    }
  },
  cover: {
    background: theme.palette.primary.main,
    [theme.breakpoints.down('sm')]: {
      width: 100,
      height: '1fr',
    },
    [theme.breakpoints.up('md')]: {

    }
  },
  cardContent: {
    padding: '16px !important',
    [theme.breakpoints.down('sm')]: {
      flex: 1
    }
  },
  playButton: {
    marginBottom: theme.spacing(1)
  }
}))

interface Props {
  shareable?: boolean
  playable?: boolean
  subtitle?: boolean
  stickyContainer: MutableRefObject<null>
}

export default ({ shareable, playable, subtitle, stickyContainer }: Props) => {
  const classes = useStyles()
  const theme = useTheme()
  const sticky = useMediaQuery(theme.breakpoints.down('sm'))

  const content = (
    <Card className={classes.card}>
      <CardMedia className={classes.cover}>
        <MediaCoverSkeleton
          variant="flat"
          color="primary"
        />
      </CardMedia>
      <CardContent className={classes.cardContent}>
        <Grid container spacing={2}>
          <Grid item md={12} sm={6}>
            <Skeleton animation="wave">
              <Typography variant="h5" component="h1">
                Artist is loading
              </Typography>
            </Skeleton>
            {subtitle && (
              <Skeleton animation="wave">
                <Typography variant="subtitle1" color="textSecondary" gutterBottom>
                  Loading
                </Typography>
              </Skeleton>
            )}
          </Grid>
          <Grid item xs>
            {playable && (
              <Button
                className={classes.playButton}
                variant="contained"
                color="primary"
                disabled
                fullWidth
              >
                Play
              </Button>
            )}
            {shareable && (
              <Button
                variant="outlined"
                disabled
                fullWidth
              >
                Share
              </Button>
            )}
          </Grid>
        </Grid>
      </CardContent>
    </Card>
  )

  if (sticky && stickyContainer.current) {
    return (
      <Portal container={stickyContainer.current}>
        <AddPropsWhenScrolled props={{ elevation: 4 }}>
          {content}
        </AddPropsWhenScrolled>
      </Portal>
    )
  } 
  else {
    return content
  }
}
