import { Card, CardContent, CardMedia, Grid, makeStyles, Typography, Link, Button, useTheme, useMediaQuery, Portal } from '@material-ui/core'
import React, { MutableRefObject, ReactElement } from 'react'
import { Link as RouterLink } from 'react-router-dom'
import { AddPropsWhenScrolled } from '.'
import LikeButton from './LikeButton'

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
      paddingTop: '100%',
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
  title: string
  subtitle?: ReactElement
  image: ReactElement|null
  onLike?: (liked: boolean) => void
  onPlay?: () => void
  onShare?: () => void
  shareable?: boolean
  likeable?: boolean
  liked?: boolean
  stickyContainer: MutableRefObject<null>
}

export default ({ title, subtitle, image, onLike, onPlay, shareable, likeable, liked, onShare, stickyContainer }: Props) => {
  const classes = useStyles()
  const theme = useTheme()
  const sticky = useMediaQuery(theme.breakpoints.down('sm'))

  const content = (
    <Card className={classes.card}>
      <CardMedia className={classes.cover}>

      </CardMedia>
      <CardContent className={classes.cardContent}>
        <Grid container spacing={2}>
          <Grid item md={12} sm={6}>
            <Typography variant="h5" component="h1">
              {title} {likeable && <LikeButton liked={liked ?? false} onClick={onLike ?? (() => {})} />}
            </Typography>
            <Typography variant="subtitle1" color="textSecondary" gutterBottom>
              {subtitle}
            </Typography>
          </Grid>
          <Grid item xs>
            <Button
              className={classes.playButton}
              variant="contained"
              color="primary"
              onClick={onPlay}
              fullWidth
            >
              Play
           </Button>
           {shareable && (
            <Button
              variant="outlined"
              onClick={onShare}
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
